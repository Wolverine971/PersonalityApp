(function () {
    angular.module('personalityApp')
        .controller('userProfileController', UserProfileController);

    UserProfileController.$inject = ['$log',
        'userService',
        'userProfileService',
        '$window',
        '$location',
        '$scope',
        '$rootScope',
        '$state',
        '$stateParams',
        'moment'];

    function UserProfileController($log,
        userService,
        userProfileService,
        $window,
        $location,
        $scope,
        $rootScope,
        $state,
        $stateParams,
        moment) {
        var vm = this;
        vm.currentUser = {};
        vm.userProfileService = userProfileService;
        vm.$onInit = _init;
        vm.id = parseInt($stateParams.id);
        vm.person = {};
        vm.save = _save;
        //vm.moment = moment;

        function _init() {
            vm.userProfileService.get(vm.id).then(_getUserSuccess, _getUserError);
        }
        function _getUserSuccess(data) {
            if (data && data.item) {
                console.log(data.item);
                vm.person = data.item;
                vm.person.friendlyDbo = moment(data.item.dbo).format("MMMM DD YYYY"); ;
            }
            else {
                console.log("no item in success");
            }
        }
        function _getUserError(error) {
            console.log(error);
            console.log("fucking fail");
        }
        function _save(data) {
            data.dbo = data.friendlyDbo;
            userProfileService.update(data).then(_getUpdateSuccess, _getUpdateError);
        }
        function _getUpdateSuccess(data) {
            console.log(data);
        }
        function _getUpdateError(error) {
            console.log(error);
        }
    }
})();