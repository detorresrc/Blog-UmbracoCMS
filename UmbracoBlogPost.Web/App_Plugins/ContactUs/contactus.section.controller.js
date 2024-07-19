(function () {
    'use strict';

    function contactUsSectionController($scope, $http) {

        var vm = this;
        
        vm.loading = false;
        vm.data = [];
        vm.meta = {
            total: 0,
            currentPage: 1
        };

        vm.page = {
            title: 'Contact Us',
            description: 'Module for contacting the site owner',
            navigation: [
                {
                    'name': 'Listing',
                    'alias': 'default',
                    'icon': 'icon-list',
                    'view': Umbraco.Sys.ServerVariables.umbracoSettings.appPluginsPath + '/ContactUs/index.html',
                    'active': true
                }
            ]
        }
        
        vm.paginationOnChange = function(e) {
            const currentPage = e.target.current;
            fetch(currentPage);
        }
        
        const fetch = function(page) {
            vm.loading = true;
            $http.get('/umbraco/backoffice/api/contactus?page=' + page)
                .then(function(response) {
                    vm.data = response.data.Data;
                    
                    vm.meta.currentPage =  response.data.MetaData.PageNumber;
                    vm.meta.total = response.data.MetaData.PageSize;
                }).finally(function() {
                    vm.loading = false;
                });
        }

        const init = function() {
            fetch(1);
        }

        init();
    }

    angular.module('umbraco')
        .controller('contactUsSectionController', contactUsSectionController);
})();
