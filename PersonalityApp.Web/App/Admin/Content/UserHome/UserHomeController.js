(function () {
    'use strict';

    angular.module('personalityApp')
        .controller('userHomeController', UserHomeController);
    UserHomeController.$inject = ['userHomeService', 'userService', 'wordLookUpService', '$window', '$scope', '$state', '$stateParams', '$timeout'];

    function UserHomeController(userHomeService, userService, wordLookUpService, $window, $scope, $state, $stateParams, $timeout) {

        var vm = this;
        vm.$onInit = _init;
        vm.banner = 'connected to controller';
        vm.userInfo = {};
        vm.roleNames = "";
        vm.userService = userService;
        vm.word = {};
        vm.submitWord = _submitWord;
        vm.wordLookUpService = wordLookUpService;

        vm.fOut = null;
        vm.help = null;
        vm.solve = null;

        function _init() {
            console.log("user home on init runnin")
            vm.userService.getUserInfo()
                .then(function (data) {
                    // if vm.getId was not specified or the logged-in user is not an Admin,
                    // show them their own home page.
                    if (data && data.item) {
                        vm.userInfo = data.item;
                        vm.roleNames = data.item.roles;
                        vm.name = vm.userInfo.firstName + " " + vm.userInfo.lastName;
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
            data.word = [];
            if (word.fOut) {
                data.word.push(word.fOut);
                vm.fOut = [];
            }
            if (word.help) {
                data.word.push(word.help);
                vm.help = [];
            }
            if (word.solve) {
                data.word.push(word.solve);
                vm.solve = [];
            }
            vm.wordLookUpService.syn(data).then(_subWordComplete, _subWordError);
        }
        function waitForLookup(word) {
            $timeout(waitForLookup, 10);

            vm.wordLookUpService.syn(data).then(_subWordComplete, _subWordError);
        }
        function _subWordComplete(data) {
            console.log("sub word success" + data)
            var i = 0;
            if (vm.fOut) {
                vm.fOut = data[i].synonyms;
                i++;
            }
            if (vm.help) {
                vm.help = data[i].synonyms;
                i++;
            }
            if (vm.solve) {
                vm.solve = data[i].synonyms;
                i++;
            }
            i = 0;

        }
        function _subWordError(error) {
            console.log("sub word error" + error)
        }
    }
})();