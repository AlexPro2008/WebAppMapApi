$().ready(() =>
    fetch('/Query/GetQuery6', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));
