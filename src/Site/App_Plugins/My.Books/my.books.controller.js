(function () {
  'use strict';

  function MyBooksController($scope, editorService) {

    if (!$scope.model.value) {
      $scope.model.value = [];
    }

    const vm = this;
    vm.items = $scope.model.value.map(item => ({value: item}));
    vm.sortableOptions = {
      axis: 'y',
      containment: 'parent',
      cursor: 'move',
      items: '> div.textbox-wrapper',
      tolerance: 'pointer',
      disabled: $scope.readonly
    };

    vm.add = function(){
      vm.items.push({value: ""});
    }

    vm.remove = function(index){
      vm.items.splice(index, 1);
    }

    const unsubscribe = $scope.$on("formSubmitting", function (ev, args) {
      $scope.model.value = vm.items.filter(item => item.value).map(item => item.value);
    });

    $scope.$on('$destroy', function () {
      unsubscribe();
    });
  }

  angular.module("umbraco").controller("My.Books.Controller", MyBooksController);

})();
