const pathMenu = new URL(window.location.href).origin.toString() + "/Menu/GetMenuJson";
const bashPath = new URL(window.location.href).origin.toString();

function writeSession(name, value) {
    if (typeof (Storage) !== "undefined")
        sessionStorage.setItem(name, value)
    else
        console.log("Sorry your browser does not support Web Storage")
}

function readSession(name) {
    if (typeof (Storage) !== "undefined")
        return sessionStorage.getItem(name);
    else
        console.log("Sorry your browser does not support Web Storage")

}


function convertToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (pad(dt.getDate().toString(),2) + "/" + dt.getMonth() + 1) + "/" + dt.getFullYear();
}

function pad(n, len) {
    let l = Math.floor(len);
    let sn = '' + n;
    let snl = sn.length;
    if (snl >= l) return sn;
    return '0'.repeat(l - snl) + sn;
}
