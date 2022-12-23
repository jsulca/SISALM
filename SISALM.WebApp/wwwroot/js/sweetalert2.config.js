//var defaultParams = {
//    title: '',
//    text: '',
//    type: null,
//    allowOutsideClick: false,
//    showConfirmButton: true,
//    showCancelButton: false,
//    closeOnConfirm: true,
//    closeOnCancel: true,
//    confirmButtonText: 'Si',
//    confirmButtonColor: '#8CD4F5',
//    cancelButtonText: 'Cancelar',
//    imageUrl: null,
//    imageSize: null,
//    timer: null,
//    customClass: '',
//    html: false,
//    animation: true,
//    allowEscapeKey: true,
//    inputType: 'text',
//    inputPlaceholder: '',
//    inputValue: '',
//    showLoaderOnConfirm: false
//};

var sweetalert2 = {
    alertConfig: ({ title, icon, text }) => {
        return {
            title,
            icon,
            text,
            confirmButtonText: 'Aceptar',
            confirmButtonColor: '#007bff'
        }
    },
    confirmationConfig: ({ title }) => {
        return {
            title,
            icon: 'warning',
            confirmButtonText: 'Si',
            confirmButtonColor: '#007bff',
            cancelButtonText: 'No',
            cancelButtonColor: '#dc3545',
            showCancelButton: true,
        }
    }
}