
var MatchController = function (matchService) {
    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-followgame", toggleAttendance);
    };

    var toggleAttendance = function (e) {
        button = $(e.target);

        var matchId = button.attr("data-match-id");

        if (button.hasClass("btn-default"))
            matchService.createAttendance(matchId, done, fail);
        else
            matchService.deleteAttendance(matchId, done, fail);
    };

    var done = function () {
        var text = (button.text() == "Add") ? "Add?" : "Add";

        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something failed");
    };

    return {
        init: init
    }

}(MatchService);
