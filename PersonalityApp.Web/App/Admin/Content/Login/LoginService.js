(function () {
    'use strict';

    angular
        .module('personalityApp')
        .factory('loginService', loginService);

    loginService.$inject = ['$http', '$q'];

    function loginService($http, $q) {
        var url = "http://localhost:54202"

        return {
            login: _login
            //getAll: _getAll
        };

        function _login(data) {
            var settings = {
                url: url + '/api/personality/loginUser',
                method: 'POST',
                cache: false,
                contentType: 'application/json; charset=UTF-8',
                data: JSON.stringify(data)
            };
            return $http(settings)
                .then(_loginComplete, _loginFailed);
        }
        function _loginComplete(response) {
            // unwrap the data from the response
            return response.data;
        }

        function _loginFailed(error) {
            var msg = 'Failed To Post';
            if (error.data && error.data.description) {
                msg += '\n' + error.data.description;
            }
            error.data.description = msg;
            return $q.reject(error);
        }
    }
})();