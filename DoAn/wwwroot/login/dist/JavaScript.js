function showLoginForm() {
    document.getElementById('customLoginForm').style.display = 'flex';
}

function hideLoginForm() {
    document.getElementById('customLoginForm').style.display = 'none';
}

// Thêm event listener để đóng modal khi click bên ngoài
document.getElementById('customLoginForm').addEventListener('click', function (e) {
    if (e.target === this) {
        hideLoginForm();
    }
});