# WoW Process Priority Manager

**WoW Process Priority Manager** is a lightweight Windows application that automatically monitors and optimizes the **World of Warcraft** process by setting its priority to **High**. This ensures smoother gameplay by giving the game higher access to system resources.

---

## Features

- Automatically detects the **World of Warcraft** process (`Wow.exe` or `WowClassic.exe`).
- Sets the process priority to **High** to optimize performance.
- Runs silently in the system tray for minimal disruption.
- Simple context menu for controlling the app (Start/Stop monitoring, Exit).

---

## How It Works

1. The application monitors running processes and looks for `Wow.exe` or `WowClassic.exe`.
2. When it finds the process, it checks its priority.
3. If the priority is not already set to **High**, the application updates it.
4. The app runs quietly in the system tray, ensuring a seamless user experience.

---

## Installation

1. Download the latest release from the [Releases](#) section.
2. Extract the downloaded `.zip` file to a folder of your choice.
3. Run the `WoWProcessPriorityManager.exe` file.

---

## Usage

1. **Launch the App**:
   - Double-click `WoWProcessPriorityManager.exe`. The app will appear in the system tray.
2. **Access the Tray Menu**:
   - Right-click the tray icon to:
     - Start/Stop monitoring.
     - Exit the application.

---

## Auto-Start Setup (Optional)

To make the app start automatically with Windows:
1. **Startup Folder**:
   - Press `Win + R`, type `shell:startup`, and press Enter.
   - Place a shortcut of `WoWProcessPriorityManager.exe` in this folder.
2. **Task Scheduler** (for admin privileges):
   - Open **Task Scheduler** and create a new task.
   - Set the task to run at logon and configure it to run with highest privileges.
   - Point the task to the `WoWProcessPriorityManager.exe` file.

---

## Development

### Build Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/WoWProcessPriorityManager.git
   ```
2. Open the project in Rider or Visual Studio.
3. Build the solution in `Release` mode.
4. The compiled executable will be available in the `bin\Release` folder.

---

## Contributing

Contributions are welcome! Feel free to fork the repository, submit issues, or create pull requests.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Acknowledgments

- Inspired by the needs of the **World of Warcraft** community to enhance gaming performance.
- Built with ❤️ by WiLLyRS.
