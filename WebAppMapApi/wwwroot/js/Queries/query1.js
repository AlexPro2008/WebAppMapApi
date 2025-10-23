$().ready(() =>
    fetch('/Query/GetQuery1', {
        method: "GET"
    })
    .then(d => d.text())
    .then(s => $("#table").html(s)));       
        
