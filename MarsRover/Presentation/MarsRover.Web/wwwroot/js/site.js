$(document).on("click", "#btnAdd", function () {
    //Reference the Name and Country TextBoxes.
    debugger;
    var txtXPosition = $("#txtXPosition");
    var txtYPosition = $("#txtYPosition");
    var selectOrientation = $("#selectOrientation");
    var txtInstructions = $("#txtInstructions");

    //Get the reference of the Table's TBODY element.
    var tBody = $("#tblRovers > TBODY")[0];

    var index = tBody.rows.length;

    //Add Row.
    var row = tBody.insertRow(-1);

    var cell = $(row.insertCell(-1));
    var inputXPosition = $("<input />");
    inputXPosition.attr("id", "RoverList_" + index + "__RoverPosition_X");
    inputXPosition.attr("name", "RoverList[" + index + "].RoverPosition.X");
    inputXPosition.attr("value", txtXPosition.val());
    cell.html(inputXPosition);

    cell = $(row.insertCell(-1));
    var inputYPosition = $("<input />");
    inputYPosition.attr("id", "RoverList_" + index + "__RoverPosition_Y");
    inputYPosition.attr("name", "RoverList[" + index + "].RoverPosition.Y");
    inputYPosition.attr("value", txtYPosition.val());
    cell.html(inputYPosition);


    cell = $(row.insertCell(-1));
    var inputOrientation = $("<input />");
    inputOrientation.attr("id", "RoverList_" + index + "__RoverPosition_Orientation");
    inputOrientation.attr("name", "RoverList[" + index + "].RoverPosition.Orientation");
    inputOrientation.attr("value", selectOrientation.val());
    cell.html(inputOrientation);

    cell = $(row.insertCell(-1));
    var inputInstructions = $("<input />");
    inputInstructions.attr("id", "RoverList_" + index + "__Instructions");
    inputInstructions.attr("name", "RoverList[" + index + "].Instructions");
    inputInstructions.attr("value", txtInstructions.val());
    cell.html(inputInstructions);

    //Clear the TextBoxes.
    txtXPosition.val("");
    txtYPosition.val("");
    txtInstructions.val("");
});

$(document).on("click", "#btnSave", function () {
    //Loop through the Table rows and build a JSON array.
    var rovers = new Array();
    $("#tblRovers TBODY TR").each(function () {
        var row = $(this);
        var rover = {};
        rover.RoverPosition.X = row.find("TD").eq(0).html();
        rover.RoverPosition.Y = row.find("TD").eq(1).html();
        rover.RoverPosition.Orientation = row.find("TD").eq(2).html();
        rover.Instructions = row.find("TD").eq(3).html();
        rovers.push(rover);
    });
});