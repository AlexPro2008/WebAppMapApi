$().ready(() =>
    fetch('/Query/GetQuery9', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));
