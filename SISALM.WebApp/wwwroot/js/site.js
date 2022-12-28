var helper = {
    error: {
        show: function (selector, htmlText) {
            $(selector).html(htmlText).hide();
            $('html, body').animate({ scrollTop: 0 }, '500', 'swing', function () {
                $(selector).slideDown(500, function () { });
            });
        }
    },
    wait: {
        modal: function (id) {
            var htmlText = `<div class="modal-dialog">
                            <div class="modal-content modal-width">
                                <div class="modal-header">
                                    <h4 class="modal-title">Cargando</h4>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body form-horizontal">
                                    <div class="progress">
                                        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                </div>
                            </div>
                        </div>`;

            $("#" + id).html(htmlText);
        },
        append: function (selector) {
            var htmlText = `<div class="progress site-progress">
                    <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-label="Animated striped example" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
                </div>`

            $(selector).prepend(htmlText);
        },
        remove: function (selector) {
            $(selector + ' .site-progress').remove();
        },
    },
    pagination: {
        btnNames: ['<i class="fa-solid fa-angles-left"></i>', '<i class="fa-solid fa-angle-left"></i>', '<i class="fa-solid fa-angle-right"></i>', '<i class="fa-solid fa-angles-right"></i>'],
        btnPages: 7,
        btnClass: 'pagination pagination-sm',
        update: function (table, btnPages, btnNames, btnClass) {
            if (btnPages == null) btnPages = helper.pagination.btnPages;
            if (btnNames == null) btnNames = helper.pagination.btnNames;
            if (btnClass == null) btnClass = helper.pagination.btnClass;

            var paginator = $(table.data('paginator'));
            var page = table.data('pageindex');
            var fn = table.data('function');
            var nPaginas = Math.ceil(table.data('totalrows') / table.data('pagesize'));
            paginator.html(null);

            var ul = $('<ul>');
            ul.addClass(btnClass);

            var li = $('<li>', { 'class': 'page-item ' });
            li.addClass(page == 0 ? 'disabled' : '');
            li.append(`<a class="page-link" href="javascript:${page == 0 ? 'void(0)' : `${fn}(0)`}">${btnNames[0]}</a>`)
            ul.append(li);

            li = $('<li>', { 'class': 'page-item ' });
            li.addClass(page == 0 ? 'disabled' : '');
            li.append(`<a class="page-link" href="javascript:${page == 0 ? 'void(0)' : `${fn}(${page - 1})`}">${btnNames[1]}</a>`)
            ul.append(li);

            if (nPaginas > 1) {
                var g = page;
                if (page < Math.ceil(btnPages / 2)) g = Math.ceil(btnPages / 2);
                if (page > nPaginas - Math.ceil(btnPages / 2) + 1) g = nPaginas - Math.ceil(btnPages / 2) + 1;

                var ini = g - Math.ceil(btnPages / 2) <= 0 ? 0 : g - Math.ceil(btnPages / 2);
                var fin = nPaginas <= btnPages ? nPaginas : g - Math.ceil(btnPages / 2) + btnPages;

                for (var i = ini; i < fin; i++) {
                    li = $('<li>', { 'class': 'page-item ' });
                    li.addClass(page == i ? 'active' : '');
                    li.append(`<a class="page-link" href="javascript:${page == i ? 'void(0)' : `${fn}(${i})`}">${i + 1}</a>`)
                    ul.append(li);
                }
            }

            nPaginas--;

            li = $('<li>', { 'class': 'page-item ' });
            li.addClass(page == nPaginas || nPaginas == 0 ? 'disabled' : '');

            li.append(`<a class="page-link" href="javascript:${page == nPaginas || nPaginas == 0 ? 'void(0)' : `${fn}(${page + 1})`}">${btnNames[2]}</a>`)
            ul.append(li);

            li = $('<li>', { 'class': 'page-item ' });
            li.addClass(page == nPaginas || nPaginas == 0 ? 'disabled' : '');
            li.append(`<a class="page-link" href="javascript:${page == nPaginas || nPaginas == 0 ? 'void(0)' : `${fn}(${nPaginas})`}">${btnNames[3]}</a>`)
            ul.append(li);

            paginator.append(ul);
        }
    },
};