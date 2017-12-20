
(function () {
    var init = function () {
        $('.menu .menuname').click(function () {
            clickMenuItem($(this));
        });
        $('.menu .menuname:eq(0)').click();

        $('.layout_dialog .cdialog_warp .dialog-head .close').click(function () {
            $('.layout_dialog').hide();
        });
    }

    var clickMenuItem = function (jDom) {
        var $menuname = jDom;
        // 点中之前是否checked状态
        var beforChecked = $menuname.hasClass('checked');

        if ($menuname.parent().parent().hasClass('menu')) {
            // 是一级菜单
            $('.menu>li>.menuname').removeClass('checked');
            $('.menu .children').hide();
        } else {
            // 是二级菜单
            $ul = $menuname.parent().parent();
            $ul.find('.menuname').removeClass('checked');
        }

        if ($menuname.next() != null && $menuname.next().length > 0 && $menuname.next().hasClass('children')) {
            // 有子节点
            $menuname.next().show();

            if (!beforChecked) {
                // 新展开的子菜单，不应该有子菜单被选中
                $menuname.next().find('.menuname').removeClass('checked');
            }
        }

        jDom.addClass('checked');
    }
    $(init);

})();


