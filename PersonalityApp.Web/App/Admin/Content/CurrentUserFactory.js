(function () {
    angular.module('personalityApp')
        .factory('currentUserFactory', currentUserFactory);
    currentUserFactory.$inject = ['$rootScope'];
    function currentUserFactory($rootScope) {
        var service = {};
        service.data = false;
        service.sendData = function (data) {
            this.data = data;
            $rootScope.$broadcast('data_shared');
        };
        service.getData = function () {
            return this.data;
        };
        return service;
    }
})();
