# WindowsServiceLogger

A simple Windows service that logs service start, stop, and elapsed events to a log file every 5 seconds. The service creates and appends log entries to a daily log file stored in the "Logs" directory of the application's base directory.

## Features

- Logs the service start time when the service starts.
- Logs the service stop time when the service stops.
- Logs an entry every 5 seconds while the service is running.
- Logs are saved in a daily log file format (`ServiceLog_yyyy_MM_dd.txt`).
- Logs are stored in the "Logs" directory located in the application's base directory.

## Prerequisites

- .NET Framework 4.7.2 or higher
- Windows operating system (for the service to run)

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/WindowsServiceLogger.git
