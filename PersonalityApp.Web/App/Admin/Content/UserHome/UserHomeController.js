(function () {
    'use strict';

    angular.module('personalityApp')
        .controller('userHomeController', UserHomeController);
    UserHomeController.$inject = ['userHomeService', 'userService', 'wordLookUpService', '$window', '$scope', '$state', '$stateParams'];

    function UserHomeController(userHomeService, userService, wordLookUpService, $window, $scope, $state, $stateParams) {

        var vm = this;
        vm.$onInit = _init;
        vm.banner = 'connected to controller';
        vm.userInfo = {};
        vm.roleNames = "";
        vm.userService = userService;
        vm.word = "";
        vm.submitWord = _submitWord;
        vm.wordLookUpService = wordLookUpService;

        function _init() {
            console.log("user home on init runnin")
            vm.userService.getUserInfo()
                .then(function (data) {
                    // if vm.getId was not specified or the logged-in user is not an Admin,
                    // show them their own home page.
                    if (data && data.item) {
                        vm.userInfo = data.item;
                        vm.roleNames = data.item.roles;
                        _emitEvent(data.item);
                    }
                    //        if (!vm.roleNames || !vm.roleNames.includes("Admin") || !vm.getId) {
                    //            vm.getId = data.item.id;
                    //        }
                    //    }
                    //    return vm.personService.personSelectById(vm.getId);
                    //})
                    //.then(function (data) {
                    //    if (data && data.item) {
                    //        vm.person = data.item;
                    //    }
                    //    else {
                    //        console.log("user home error");
                    //    }

                    //};
                })
        };
        function _emitEvent(userData) {
            $scope.$emit('userLoggedIn', userData);
        }
        function _submitWord(word) {
            var data = {};
            data.word = word;
            vm.wordLookUpService.post(data).then(_subWordComplete, _subWordError);
        }
        function _subWordComplete(data) {
            console.log("sub word success" + data)
        }
        function _subWordError(error) {
            console.log("sub word error" + error)
        }
    }
})();