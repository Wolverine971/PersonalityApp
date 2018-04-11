(function () {
    angular.module('personalityApp')
        .factory('accountService', accountService);
    accountService.$inject = ['$http', '$q'];

    function accountService($http, $q) {
        return {
            postLogin: _postLogin,
            postRegistration: _postRegistration,
            getRole: _getRole,
            getNameByEmail: _getNameByEmail,
            put: _put,
            postTokenSendEmail: _postTokenSendEmail,
            checkConfirmationStatus: _checkConfirmationStatus
        };

        function _postLogin(userData) {
            var settings = {
                url: "/api/accounts/login",
                method: 'POST',
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true,
                data: JSON.stringify(userData)
            };
            return $http(settings)
                .then(_submitComplete, _submitFailed);
        }
        function _submitComplete(response) {
            console.log("Post ajax successfull!");
            console.log(response.data);
            return response.data;
        }
        function _submitFailed(error) {
            console.log("Post ajax unsuccessfull.");
            return $q.reject(error);
        }

        function _postRegistration(userData) {
            var settings = {
                url: "/api/accounts/register",
                method: 'POST',
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true,
                data: JSON.stringify(userData)

            };
            return $http(settings)
                .then(_registrationComplete, _registrationFailed);
        }
        function _registrationComplete(response) {
            console.log("Registration Post Ajax complete!");
            console.log(response.data);
            return response.data;
        }
        function _registrationFailed(error) {
            console.log("Registration Post Ajax failed.");
            return $q.reject(error);
        }
        function _getRole() {
            var settings = {
                url: "/api/roles",
                method: 'GET',
                withCredentials: true,
                cache: false,
                responseType: 'json'
            };
            return $http(settings)
                .then(_getAllComplete, _getAllFailed);
        }
        function _getAllComplete(response) {
            return response.data;
        }

        function _getAllFailed(error) {
            var msg = 'Failed to retrieve blogs';
            if (error.data && error.data.description) {
                msg += '\n' + error.data.description;
            }
            error.data.description = msg;
            return $q.reject(error);
        }

        function _getNameByEmail(email) {
            var settings = {
                url: "/api/accounts/" + email + "/",
                method: 'GET',
                withCredentials: true,
                cache: false,
                responseType: 'json'
            };
            return $http(settings)
                .then(_getEmailComplete, _getEmailFailed);
        }
        function _getEmailComplete(response) {
            return response.data;
        }

        function _getEmailFailed(error) {
            var msg = 'Failed to retrieve blogs';
            if (error.data && error.data.description) {
                msg += '\n' + error.data.description;
            }
            error.data.description = msg;
            return $q.reject(error);
        }
        function _put(email) {
            var settings = {
                url: '/api/accounts/' + email + '/',
                method: 'PUT',
                withCredentials: true,
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                data: JSON.stringify(email)
            };
            return $http(settings)
                .then(_putComplete, _putFailed);
        }

        function _putComplete(response) {
            return response.data;
        }

        function _putFailed(error) {
            console.log("Error");
        }
        function _postTokenSendEmail(email) {
            var settings = {
                url: "/api/accounts/" + email + "/",
                method: "POST",
                cache: false,
                responseType: "json",
                contentType: "application/json; charset-UTF=8",
                data: JSON.stringify(email),
                withCredentials: true
            }
            return $http(settings)
                .then(_onSuccess, _onError);
        }
        function _checkConfirmationStatus(email) {
            var settings = {
                url: '/api/accounts/check/' + email + "/",
                method: 'GET',
                withCredentials: true,
                cache: false,
                responseType: 'json'
                
            };
            return $http(settings)
                .then(_onSuccess, _onError);
        }
        function _onSuccess(response) {
            console.log("ajax  success!");
            return response;
        }
        function _onError(error) {
            console.log("ajax  error!");
            if (error.data && error.data.description) {
                msg += '\n' + error.data.description;
            }
            error.data.description = msg;
            return $q.reject(error);
        }
    }
})();