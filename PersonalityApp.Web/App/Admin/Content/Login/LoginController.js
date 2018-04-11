(function () {
    'use strict';

    angular
        .module('personalityApp')
        .controller('LoginController', loginController);

    loginController.$inject = [
        'loginService'
    ];

    function loginController(loginService) {

        var vm = this;
        vm.loginService = loginService;
        vm.login = _login;
        vm.email = "";
        vm.password = "";

        function _login() {
            var data = {
                email: vm.email,
                password: vm.password
            }

            vm.loginService.login(data).then(_loginSuccess, _loginError)
        }
        function _loginSuccess(data) {
            if (data) {
                console.log('login success ' + data);
                vm.email = "";
                vm.password = "";
            }
            else {
                console.log('login failed');
            }
        }
        function _loginError(error) {
            console.log(error);
        }
    }
})();