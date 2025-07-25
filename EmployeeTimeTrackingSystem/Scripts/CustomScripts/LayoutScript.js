function SidebarToggle() {
    $('#sidebarToggle').click(function () {
        $('#sidebar').toggleClass('collapsed');
        $('#mainContent').toggleClass('expanded');

        if ($('#sidebar').hasClass('collapsed')) {
            $('#sidebarToggle').text('Open →');
        } else {
            $('#sidebarToggle').text('← Hide');
        }
    });
}

$(document).ready(function () {
    SidebarToggle();
});
