

const notyf = new Notyf({
    duration: 3000, //3 sec
    position: {
        x: 'right',
        y: 'top',
    },
    types: [
        {
            type: 'success',
            dismissible: true
        },
        {
            type: 'warning',
            dismissible: true
        },
        {
            type: 'error',
            dismissible: true
        }
    ]
});