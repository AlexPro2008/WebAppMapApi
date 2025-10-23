$().ready(() =>
    fetch('/Query/GetQuery2', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));
