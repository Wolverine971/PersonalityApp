(function () {
    angular.module('personalityApp')
        .factory('wordLookUpService', WordLookUpService);
    WordLookUpService.$inject = ['$http', '$q'];

    function WordLookUpService($http, $q) {
        return {
            syn: _syn,
        };

        function _syn(data) {
            var settings = {
                url: "/api/word/syn",
                method: 'POST',
                cache: false,
                responseType: 'json',
                contentType: 'application/json; charset=UTF-8',
                withCredentials: true,
                data: JSON.stringify(data)
            };
            return $http(settings)
                .then(_postComplete, _postFailed);
        }
        function _postComplete(response) {
            console.log("Post ajax successfull!");
            console.log(response.data);
            return response.data;
        }
        function _postFailed(error) {
            console.log("Post ajax unsuccessfull.");
            return $q.reject(error);
        }
    }
})();