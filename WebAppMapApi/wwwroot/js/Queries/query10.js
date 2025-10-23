$().ready(() =>
    // fetch api
    fetch('/Query/GetQuery10', {
        method: "GET"
    }).then(d => d.text())
        .then(s => {
            $("#table").html(s);
        })
);
