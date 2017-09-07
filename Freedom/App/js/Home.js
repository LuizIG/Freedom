
var graph = new Rickshaw.Graph({
    element: document.querySelector("#chart"),
    width: 350,
    height: 400,
    renderer: 'bar',
    series: [{
        data: [{ x: 0, y: 40 }, { x: 1, y: 49 }, { x: 2, y: 67 }, { x: 3, y: 78 }, { x: 4, y: 56 }],
        color: 'steelblue'
    }]
});

graph.render();