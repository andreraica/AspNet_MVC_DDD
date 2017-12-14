angular.module("budgetApp").service('OrcamentoServices', function ($http) {

    var uriBase = 'http://localhost:63867/api';
    
    refreshToken = function (uri) {
        
        var uriBaseAuth = 'http://localhost:63867';
        var clientId = 'client';
        var secret = "secret";

        if (localStorage.getItem("oAuthRefreshToken") != null) {

            var data = "grant_type=refresh_token&client_id=" + clientId + "&client_secret=" + secret + "&refresh_token=" + localStorage.getItem("oAuthRefreshToken") + "&crossDomain=true";

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                },
                async: false
            }

            $http.post(uriBaseAuth + '/token', data, config)
                .success(function (data) {
                    alert('blz 1');
                    localStorage.setItem("oAuthToken", data.access_token);
                    localStorage.setItem("oAuthRefreshToken", data.refresh_token);
                })
                .error(function (data, status, header, config) {
                    alert('estranho');
                    var erro = data + ' - ' + status + ' - ' + header + ' - ' + config;
                    alert('Erro no Serviço de Refresh_Token ' + erro);
                });

        }
        else
            alert('Erro Autenticação Refresh_Token de Serviço ' + uri);

        
    };

    this.get = function (uri) {
        var configToken = {
            headers: { 'Authorization': 'bearer ' + localStorage.getItem("oAuthToken") }
        }

        return $http.get(uriBase + uri, configToken).error(function (data, status, headers, config) {
            refreshToken(uri);
        });
    };

    this.post = function (uri, data) {
        var configToken = {
            headers: { 'Authorization': 'bearer ' + localStorage.getItem("oAuthToken") }
        }

        return $http.post(uriBase + uri, JSON.stringify(data), configToken).error(function (data, status, headers, config) {
            alert('Erro Serviço Post ' + uri);
        });
    };

    this.put = function (uri, data) {
        var configToken = {
            headers: { 'Authorization': 'bearer ' + localStorage.getItem("oAuthToken") }
        }

        return $http.put(uriBase + uri, JSON.stringify(data), configToken).error(function (data, status, headers, config) {
            alert('Erro Serviço Put ' + uri);
        });
    };

    this.delete = function (uri) {
        var configToken = {
            headers: { 'Authorization': 'bearer ' + localStorage.getItem("oAuthToken") }
        }

        return $http.delete(uriBase + uri, configToken).error(function (data, status, headers, config) {
            alert('Erro Serviço Delete ' + uri);
        });
    };

});