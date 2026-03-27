const { app, BrowserWindow } = require('electron');
const { spawn } = require('child_process')
const path = require('path');
const { start } = require('repl');

let apiProcess;

function startApi() {
    const isDev = !app.isPackaged;

    const apiPath = isDev
        ? path.join(__dirname, 'api', 'TitleTrack.Server.exe')   // dev mode
        : path.join(process.resourcesPath, 'api', 'TitleTrack.Server.exe'); // packaged
    
    apiProcess = spawn(apiPath, [], {
        cwd: path.dirname(apiPath),
        windowsHide: true
    });

    apiProcess.stdout.on('data', data => console.log(`API: ${data}`));
    apiProcess.stderr.on('data', data => console.error(`API Error: ${data}`));
}

function stopApi() {
    if (apiProcess) apiProcess.kill();
}

function createWindow() {
    const win = new BrowserWindow({
        width: 1200,
        height: 800,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
            contextIsolation: true
        }
    });

    if (process.env.NODE_ENV === 'development') {
        win.loadURL('http://localhost:4200');
        win.webContents.openDevTools();
    } else {
        win.loadFile(path.join(__dirname, '../dist/titletrack.client/browser/index.html'));
    }
}

app.whenReady().then(() => {
    startApi();
    createWindow();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});

app.on('before-quit', stopApi); 