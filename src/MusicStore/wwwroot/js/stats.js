$(document).ready(function () {

    var pie = new d3pie("myPie", {
        header: {
            title: {
                text: "Stats:"
            }
        },
        data: {
            content: [
                { label: "Bad", value: +gen1, color: "#bf0000" },
                { label: "Good", value: +gen2, color: "#CC6633" },
            ]
        }, size: {
            canvasHeight: 350,
            canvasWidth: 350,
            pieInnerRadius: 12,
            pieOuterRadius: null
        },
    });

 
});