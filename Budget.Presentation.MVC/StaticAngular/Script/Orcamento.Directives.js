angular.module("budgetApp").directive('ngValorminimo', function () {

	return {
		restrict: 'A',
		require: 'ngModel',
		link: function ($scope, $element, $attrs, ngModel) {
			$scope.$watch($attrs.ngModel, function (value) {
				if (value <= 0)
					ngModel.$setValidity($attrs.ngModel, false)
				else
					ngModel.$setValidity($attrs.ngModel, true)
			});
		}
	}

});

angular.module("budgetApp").directive('ngBlur', function () {

	return {
		restrict: 'A',
		require: 'ngModel',
		link: function ($scope, $element, $attrs, ngModel) {
			$scope.$watch($attrs.ngModel, function (value) {
				$element.on('blur', function () {
					if (ngModel.$invalid)
						$element.addClass('erro');
					else
						$element.removeClass('erro');
				});
			});
		}
	}

});

//TODO: falta configurar pra formato português, não implementado em tela
angular.module("budgetApp").directive('ngDatavalida', function () {

    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, $element, $attrs, ngModel) {
            $scope.$watch($attrs.ngModel, function (value) {
                if (angular.isDate(value))
                    ngModel.$setValidity($attrs.ngModel, true)
                else
                    ngModel.$setValidity($attrs.ngModel, false)
            });
        }
    }

});