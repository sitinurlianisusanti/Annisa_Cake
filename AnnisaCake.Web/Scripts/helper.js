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