$().ready(() =>
    fetch('/Query/GetQuery8', {
        method: "GET"
    })
        .then(d => d.text())
        .then(s => $("#table").html(s)));

