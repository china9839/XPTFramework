
var safelogin = (function(){
    var _random = '';
    var _action = '';
    var _success;
    var _fail;
    var _logincount = 0;

    var sign = function(usr, pwd) {
        var _sign = usr + pwd + _random;
        return hex_md5(_sign);
    }

    var init = function(random, action, success, fail) {
        _random = random;
        _action = action;
        _success = success;
        _fail = fail;
    }

    var login = function(usr, pwd) {
        var post = {
            usr: usr,
            random: _random,
            pwd: sign(usr, pwd)
        };
        _logincount++;
        $.post(_action, post, function (d) {
            if (d.state == 1) {
                // 验证成功
                _logincount = 0;
                _success(d);
                return;
            } else if (d.state == 2) {
                // 页面过期
                if (_logincount > 5) {
                    _fail(d);
                    return;
                }
                _random = d.data;
                login(usr, pwd);
            } else {
                // 验证失败
                _logincount = 0;
                _fail(d);
                return;
            }
        }, 'json');
    }

    return {
        init: init,
        login: login
    };
})();

