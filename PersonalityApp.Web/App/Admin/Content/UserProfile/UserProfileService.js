(function () {
    angular.module('personalityApp')
        .factory('userProfileService', UserProfileService);
    UserProfileService.$inject = ['$http', '$q'];

    function UserProfileService($http, $q) {
        return {
            get: _get,
            post: _post,
            update: _update
        };

        function _get(id) {
            var settings = {
                url: "/api/user/" + id,
                method: 'GET',
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true
                //data: JSON.stringify(userData)
            };
            return $http(settings)
                .then(_getComplete, _getFailed);
        }
        function _getComplete(response) {
            console.log("Post ajax successfull!");
            console.log(response.data);
            return response.data;
        }
        function _getFailed(error) {
            console.log("Post ajax unsuccessfull.");
            return $q.reject(error);
        }

       
        function _post(userData) {
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
        

        function _update(userData) {
            var settings = {
                url: "/api/user/update",
                method: 'PUT',
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true,
                data: JSON.stringify(userData)
            };
            return $http(settings)
                .then(_updateComplete, _updateFailed);
        }
        function _updateComplete(response) {
            console.log("Update ajax successfull!");
            console.log(response.data);
            return response.data;
        }
        function _updateFailed(error) {
            console.log("Update ajax unsuccessfull.");
            return $q.reject(error);
        }
    }


})();