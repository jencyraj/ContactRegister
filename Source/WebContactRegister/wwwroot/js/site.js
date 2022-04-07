// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

function DeleteItem(btn) {
    var table = document.getElementById('ComTable');
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("This Row Cannot Be Deleted!! The company should need at least one contact Person");
        return;
    }

    var btnIdx = btn.id.replaceAll('btnremove-', '');
    var idofIsDeleted = btnIdx + "__IsDeleted";

    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
    document.getElementById(hidIsDelId).value = "true";
    $(btn).closest('tr').hide();
    
    
}


function AddItem(btn) {
    var table = document.getElementById("ComTable");
    var rows = table.getElementsByTagName('tr');
    var rowOuterHtml = rows[rows.length - 1].outerHTML;

    //last row index 
    var lastrowIdx = rows.length - 2;//document.getElementById('hdnLastIndex').value;
    var nextrowIdx = eval(lastrowIdx) + 1;// eval func: convert the number stored string to num
    

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_' , '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;

    var x = document.getElementsByTagName("INPUT");
    for (var cnt = 0; cnt < x.length; cnt++) {
        
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
        else if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = 0;


    }

    rebindvalidators();

}
function rebindvalidators() {
    var $form = $("#RegFormID"); //get referance of the form by id
    $form.unbind(); //remove all the controls from jquery
    $form.data("validator", null); // validate form
    $.validator.unobtrusive.parse($form);// add the validator again
    $form.validate($form.data("unobtrusiveValidation").options) // rebind 

}
