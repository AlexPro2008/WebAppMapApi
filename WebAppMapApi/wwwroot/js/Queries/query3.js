$().ready(() =>
    fetch('/Query/GetQuery3', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));       

