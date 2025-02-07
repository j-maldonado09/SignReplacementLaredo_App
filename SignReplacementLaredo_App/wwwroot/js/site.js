// Write your Javascript code.

function fnShowError(e) {
    fnShowMessage(e.xhr.responseText, "Error");
}

function fnShowSuccess(successText) {
    fnShowMessage(successText, "Success");
}

function fnShowMessage(message, title) {
    var dialog = $("#messageDialog").data("kendoDialog");
    dialog.content(message);
    dialog.title(title);
    dialog.open();
}