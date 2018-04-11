(function () {
    angular.module('personalityApp')
        .controller('indexController', IndexController);

    IndexController.$inject = ['$log',
        'userService',
        '$window',
        '$location',
        '$scope',
        '$rootScope',
        '$state'];

    function IndexController($log,
        userService,
        $window,
        $location,
        $scope,
        $rootScope,
        $state) {
        var vm = this;
        vm.currentUser = null;
        vm.userService = userService;
        vm.$scope = $scope;
        vm.isAdmin = false;
        vm.isStaff = false;
        vm.isMentee = false;
        vm.isMentor = false;
        vm.logout = _logout;
        vm.goToMyProfile = _goToMyProfile;
        vm.goToMyHome = _goToMyHome;
        //vm.startTour = _startTour;
        vm.$onInit = _init;
        vm.toggleSideBar = _toggleSideBar;
        vm.sideBarToggle = "active";
        vm.sideBarImg = "glyphicon glyphicon-arrow-right";


        function _toggleSideBar() {
            if (vm.sideBarToggle === "active") {
                vm.sideBarToggle = null;
                vm.sideBarImg = "glyphicon glyphicon-arrow-left";
            }
            else {
                vm.sideBarToggle = "active";
                vm.sideBarImg = "glyphicon glyphicon-arrow-right";
            }
        }
        //vm.loadActionItems = _loadActionItems;

        function _init() {
            _startUp();
        }

        function _logout() {
            vm.userService.logOut()
                .then(_loggedOutComplete, _loggedOutFailed);
        }
        function _loggedOutComplete(data) {
            $log.log('logout successful!');
            $window.location.href = '/';
        }
        function _loggedOutFailed(data) {
            $log.log('logout failed');
        }

        function _startUp() {
            vm.userService.getUserInfo()
                .then(_getUserInfoSuccess, _getUserInfoError);
        }

        function _getUserInfoError() {
            $log.error("There has been an error retrieving the user info!");
        }
        function _getUserInfoSuccess(userData) {
            if (!userData.item && !userData.id) {
                console.log("No User");
                $state.go('account');
            }
            else if (userData.item) {
                vm.currentUser = userData.item;
            }
            else if (userData.id) {
                vm.currentUser = userData; 
            }
            else {
                console.log("index controller doesnt have user and IDK what is wrong");
                $state.go('account');
            }
            vm.isAdmin = vm.currentUser && vm.currentUser.roles && vm.currentUser.roles.includes("Admin");
            vm.isStaff = vm.currentUser && vm.currentUser.roles && vm.currentUser.roles.includes("Staff");
            vm.isNewUser = vm.currentUser && vm.currentUser.roles && vm.currentUser.roles.includes("NewUser");
            vm.isUser = vm.currentUser && vm.currentUser.roles && vm.currentUser.roles.includes("User");

            $log.log("Logged in as : " + vm.currentUser.firstName + " " + vm.currentUser.lastName);
                //_loadActionItems();
        }

        $rootScope.$on('userLoggedIn', function (event, data) {
            console.log("event:" + event);
            console.log("data:" + data);
            _getUserInfoSuccess(data);
        });

        //$rootScope.$on("LoadActionItems", _loadActionItems);

        //function _loadActionItems() {
        //    vm.actionItemService.loadActionItemsByPerson(vm.currentUser.id)
        //        .then(_loadActionItemsSuccess, _loadActionItemsError);
        //}

        //function _loadActionItemsError(error) {
        //    $log.error(error);
        //}

        //function _loadActionItemsSuccess(response) {
        //    vm.items = [];
        //    if (response !== null) {
        //        for (var i = 0; i < response.length; i++) {
        //            if (response[i].actionItemStatus.id === 1) {
        //                vm.items.push(response[i]);
        //            }
        //        }
        //    }
        //}

        function _goToMyProfile() {
            $state.go('userProfile', { id: vm.currentUser.id });
        }

        function _goToMyHome() {
            $state.go('userHome', { id: vm.currentUser.id });
        }

    }

})();