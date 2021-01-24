

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