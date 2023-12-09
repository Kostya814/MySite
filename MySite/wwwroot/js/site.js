let btn_ok = document.getElementById("btn_ok");
let btn_cancel = document.getElementById("btn_cancel");
let elements = document.getElementsByClassName("intput-1");
let labels = document.getElementsByClassName("labeinfo");
var modal = new bootstrap.Modal(document.querySelector(".modal"));
let textmodal = document.querySelector(".modal-body p");
let modal2 = document.querySelector(".modal");
let textEdit = document.querySelector("#myTextarea");
let btnEdit = document.querySelector("#editButton"); 
var isEdit = false;

btnEdit.onclick = () => {
    if (!isEdit) {
        isEdit = true;
        textEdit.disabled = false;
        btnEdit.textContent = "Сохранить";
        
    }
    else {
        isEdit = false;
        textEdit.disabled = true;
        btnEdit.textContent = "Редактировать";
    }
    
};

modal2.addEventListener("hidden.bs.modal", () => {
    clear();
});
btn_ok.onclick = () => {
    let arr = [elements.length - 1];
    let text = "";
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value === "" || elements[i].value === NaN) arr[i] = "данные не указаны";
        else arr[i] = elements[i].value;
        text += labels[i].textContent + " - " + arr[i] + "\n";
    }
    textmodal.textContent = text;
    modal.show();
};
function clear()
{
    for (var i = 0; i < elements.length; i++) {
        elements[i].value = "";
    }
}
btn_cancel.onclick = () => {
    if (!confirm("Очистить все поля на форме?")) return;
    clear();
};


