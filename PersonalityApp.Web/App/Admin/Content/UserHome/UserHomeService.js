(function () {
    angular.module('personalityApp')
        .factory('userHomeService', UserHomeService);
    UserHomeService.$inject = ['$http', '$q'];

    function UserHomeService($http, $q) {
        return {
            postLogin: _postLogin
        };

        function _postLogin(userData) {
            var settings = {
                url: "/api/home/",
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
    }
})();