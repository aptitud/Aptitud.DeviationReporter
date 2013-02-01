var Aptitud = Aptitud || {};
var deviationTypeDefaults;

Aptitud.DeviationReporter = Aptitud.DeviationReporter || {}

(function(){
    function updateDeviationHours(val) {
        var deviationHours = $('#deviationHours');
        var current = parseFloat(deviationHours.val(), 10);
        var result = current + val;

        if (result < deviationTypeDefaults.MinimumHours) {
            result = deviationTypeDefaults.MinimumHours;
        }

        if (result > deviationTypeDefaults.MaximumHours) {
            result = deviationTypeDefaults.MaximumHours;
        }

        deviationHours.val(result);
    }

    function getReporters() {
        $.ajax({
            url: "/api/reporter",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            success: function (data) {
                $.each(data, function(index, element) {
                    $("#username-choice").append("<option value = " + element.Id + ">" + element.Id + "</option>");
                });
            },
            error: function (msg) {
                alert('An error occurred trying to get reporters.');
            }
        });
    }

    function updateDefaultHoursForDeviationType() {
        var deviationType = $("input:radio[name=deviationType]:checked").val();
        var deviationHours = $('#deviationHours');
        $.ajax({
            url: "/api/deviation?deviationType=" + deviationType,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            success: function (data) {
                deviationTypeDefaults = data;
                deviationHours.val(deviationTypeDefaults.DefaultHours);
            },
            error: function (msg) {
                alert('Failed ' + msg);
                deviationTypeDefaults.DefaultHours = 8.0;
                deviationTypeDefaults.MaximumHours = 8.0;
                deviationTypeDefaults.MinimumHours = 0.0;
                deviationHours.val(8.0);
            }
        });
    }

    function generateCSV() {
        $.ajax({
            url: "/api/deviation/",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processdata: true,
            success: function (data) {
                var csvdata = "data:application/octet-stream,";
                $.each(data, function (index, element) {
                    var numstr = new String(element.Duration).replace(":00:00", "");
                    csvdata += element.Reporter + ";" + element.DeviationType + ";" + dateFormat(new Date(element.ReportDate), "YYYYMMDD") + ";" + numstr + ";\r\n";
                });
                window.location = encodeURI(csvdata);
            },
            error: function (msg) {
                alert('Failed ' + msg);
            }
        });
    }
})();