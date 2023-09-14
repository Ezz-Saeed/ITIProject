

document.addEventListener('DOMContentLoaded', function () {
    var deleteButton = document.getElementById('Delete');
    deleteButton.addEventListener('click', confirmDelete);
});

function confirmDelete(event) {
    if (!confirm("Are you sure you want to delete?")) {
        event.preventDefault();
        return;
    }

}