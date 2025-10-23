$().ready(() =>
    fetch('/Query/GetQuery7', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));
