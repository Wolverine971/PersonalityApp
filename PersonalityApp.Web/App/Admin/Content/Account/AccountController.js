(function () {
    'use strict';

    angular.module('personalityApp')
        .controller('accountController', AccountController);
    AccountController.$inject = ['accountService', '$window', '$scope', '$state', '$stateParams'];

    function AccountController(accountService, $window, $scope, $state, $stateParams) {
        var vm = this;
        vm.accountService = accountService;
        vm.postRegister = _postRegister;
        vm.submitEmail = _submitEmail;
        vm.postLogin = _postLogin;
        vm.items = [];
        vm.item = null;
        //vm.$onInit = _getRoles;
        vm.checkEmail = _checkEmail;
        vm.id = null;
        vm.showRoleOptions = true;
        vm.keepSignedIn = false;
        vm.$scope = $scope;
        vm.login = true;
        vm.register = false;
        vm.forgotPassword = false;

        function _checkEmail() {
            vm.accountService.getNameByEmail(vm.registerEmail).then(_getEmailSuccess, _getEmailFailed);
        }

        function _getEmailSuccess(data) {
            console.log("getEmail successfull!");
            console.log(data);
            if (data.item === null) {
                console.log("this is a new user");
            }
            else if (data.item.passwordHash) {
                _getEmailFailed();
            }
            else if (data.item.person === null) {
                console.log("new user");
            }
            else {

                swal({
                    title: 'Is this you?',
                    text: data.item.person.firstName + " " + data.item.person.lastName,
                    type: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No',
                    confirmButtonClass: 'btn btn-success',
                    cancelButtonClass: 'btn btn-danger',
                    buttonsStyling: false
                }).then(function () {
                    vm.$scope.$apply(function () {
                        vm.registerName = data.item.person.firstName;
                        vm.registerLastName = data.item.person.lastName;
                        vm.registerRoles = data.item.roleIds;
                        vm.id = data.item.person.id;
                        vm.showRoleOptions = false;
                    });
                }, function (dismiss) {

                    if (dismiss === 'cancel') {
                        swal(
                            'There has been an error!',
                            'Your email is already in use! Please contact a staff member to help you.',
                            'error'
                        );
                    }
                    vm.$scope.$apply(function () {
                        vm.registerEmail = null;
                        vm.registerForm.$setUntouched();
                        vm.registerForm.$setPristine();

                    });
                });
            }
        }

        function _getEmailFailed() {
            swal(
                'Wait!',
                'You have already completed an account registration. If you have forgotten your password, click the question mark at the bottom of the page.',
                'error'
            );
            console.log("getEmail has failed.");
        }

        function _postLogin() {

            vm.userData = {
                Email: vm.loginEmail,
                Password: vm.loginPassword,
                IsPersistent: vm.keepSignedIn
            };
            vm.accountService.postLogin(vm.userData)
                .then(_postLoginSuccess, _postLoginFailed);
        }

        function _postLoginSuccess(userData) {

            console.log("Post Successful");
            console.log(userData);
            $state.go('userHome');
        }

        function _postLoginFailed() {
            swal(
                'Wait',
                'There has been an error!' +
                ' If you would like to register, click the + button below. If you have registered, please check your email for a confirmation link.',
                'error'
            );
            vm.registerForm.$setUntouched();
            vm.registerForm.$setPristine();
            console.log("Post Failed");
            vm.login = false;
            vm.register = true;
        }

        function _postRegister() {
            vm.userData = {
                Id: vm.id,
                FirstName: vm.registerName,
                LastName: vm.registerLastName,
                Email: vm.registerEmail,
                Password: vm.registerPassword,
                RoleId: parseInt(vm.roleOptions)
            };
            vm.accountService.postRegistration(vm.userData)
                .then(_postRegisterSuccess, _postRegisterFailed);
        }

        function _postRegisterSuccess(userData) {

            console.log("Post Successful");
            console.log(userData);
            swal('A confirmation email has been sent!');

        }

        function _postRegisterFailed() {
            vm.registerForm.$setUntouched();
            vm.registerForm.$setPristine();
            console.log("Register has Failed");
            swal(
                'There has been an error.',
                'You may already have an account. If you forgot your password, click the question mark at the bottom of the form. If your email is already in use and its not you, contact a staff member to help you.',
                'error'
            );
            //$.growl({
            //    message: 'An error has occurred. You may already have an account. If you forgot your password, click the question mark at the bottom of the form.',
            //}, {
            //        element: 'body',
            //        type: 'danger',
            //        allow_dismiss: true,
            //        offset: {
            //            x: 20,
            //            y: 85
            //        },
            //        spacing: 10,
            //        z_index: 1031,
            //        delay: 2000,
            //        url_target: '_blank',
            //        mouse_over: false,

            //    });
        }

        function _submitEmail() {
            vm.accountService.checkConfirmationStatus(vm.forgottenPassEmail).then(_checkSuccess, _checkError);
        }

        function _checkSuccess(response) {
            console.log("check controller success");
            console.log(response);
            if (response.data.item === null) {
                swal(
                    'Wait!',
                    'You do not have an account registered.',
                    'error'
                );
            }
            else if (response.data.item.isEmailConfirmed === false) {
                swal(
                    'Wait!',
                    'Your email address is not confirmed. Please check your inbox for a confirmation email.',
                    'error'
                );
            } else {
                var data = {
                    email: vm.forgottenPassEmail
                };
                console.log("this is a valid request");
                vm.accountService.postTokenSendEmail(data).then(_tokenEmailSuccess, _tokenEmailError);
            }
        }
        function _checkError(error) {
            console.log("check controller error");
            console.log(error);
        }
        function _tokenEmailSuccess(response) {
            console.log("post email success");
            console.log(response);

            swal('Email sent!',

            );
        }
        function _tokenEmailError(error) {
            console.log("post email error");
            console.log(error);
        }



    }

})();