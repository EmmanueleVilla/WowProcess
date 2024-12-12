using System.Diagnostics;

namespace WowProcess;
public class TrayApplication : IDisposable
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenuStrip _trayMenu;
        private Thread _monitoringThread = null!;
        private bool _isMonitoring;
        private readonly string[] _targetProcesses = ["Wow", "WowClassic"];

        public TrayApplication()
        {
            // Set up the tray menu
            _trayMenu = new ContextMenuStrip();
            _trayMenu.Items.Add("Start Monitoring", null, StartMonitoring!);
            _trayMenu.Items.Add("Stop Monitoring", null, StopMonitoring!);
            _trayMenu.Items.Add("Exit", null, Exit!);

            // Set up the tray icon
            _trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "WoW Process Priority Manager",
                ContextMenuStrip = _trayMenu,
                Visible = true
            };

            // Start monitoring automatically
            StartMonitoring(null!, null!);
        }

        private void StartMonitoring(object sender, EventArgs e)
        {
            if (_isMonitoring) return;

            _isMonitoring = true;
            _monitoringThread = new Thread(MonitorProcesses)
            {
                IsBackground = true
            };
            _monitoringThread.Start();
            ShowMessage("Monitoring started.");
        }

        private void StopMonitoring(object sender, EventArgs e)
        {
            if (!_isMonitoring) return;

            _isMonitoring = false;
            _monitoringThread?.Join();
            ShowMessage("Monitoring stopped.");
        }

        private void MonitorProcesses()
        {
            while (_isMonitoring)
            {
                foreach (var processName in _targetProcesses)
                {
                    try
                    {
                        var processes = Process.GetProcessesByName(processName);
                        Console.WriteLine("Found processes: " + processes.Length);
                        foreach (var process in processes)
                        {
                            if (process.PriorityClass == ProcessPriorityClass.High)
                            {
                                Console.WriteLine("Skipping process: " + process.ProcessName);
                                continue;
                            }
                            process.PriorityClass = ProcessPriorityClass.High;
                            process.PriorityBoostEnabled = true;
                            ShowMessage($"Set priority of {process.ProcessName} (ID: {process.Id}) to High.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Error: {ex.Message}");
                    }
                }

                Thread.Sleep(60 * 1000); // Check every minute
            }
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void Exit(object sender, EventArgs e)
        {
            StopMonitoring(null!, null!);
            _trayIcon.Visible = false;
            Application.Exit();
        }

        public void Dispose()
        {
            StopMonitoring(null!, null!);
            _trayIcon.Dispose();
            _trayMenu.Dispose();
        }
    }
    