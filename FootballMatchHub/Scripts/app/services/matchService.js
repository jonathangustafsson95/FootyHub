
var MatchService = function () {
    var createAttendance = function (matchId, done, fail) {
        $.post("/api/playedgames", { matchId: matchId })
            .done(done)
            .fail(fail);
    };

    var deleteAttendance = function (matchId, done, fail) {
        $.ajax({
            url: "/api/playedgames/" + matchId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();
