(function () {
    'use strict';

    window.APP = window.APP || {};
    APP.NAME = "personalityApp";

    angular
        .module(APP.NAME, [
            'ui.router'
            , 'moment-picker'
        ]);
    angular.module(APP.NAME).config(configure);
    angular.module(APP.NAME).value("moment", moment);
    configure.$inject = ['$stateProvider', '$locationProvider'];

    function configure($stateProvider, $locationProvider, $urlRouterProvider) {

        //$urlRouterProvider.otherwise('/account');

        $stateProvider.state({
            name: 'stary',
            component: 'stary',
            url: '/stary'
        });

        $stateProvider.state({
            name: 'login',
            component: 'login',
            url: '/login'
        });

        $stateProvider.state({
            name: 'account',
            component: 'account',
            url: '/account'
        });

        $stateProvider.state({
            name: 'userHome',
            component: 'userHome',
            url: '/userHome'
        });

        $stateProvider.state({
            name: 'userProfile',
            component: 'userProfile',
            url: '/userProfile/{id}'
        });
    }
})();