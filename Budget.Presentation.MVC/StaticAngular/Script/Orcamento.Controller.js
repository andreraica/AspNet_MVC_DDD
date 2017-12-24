/*ORÇAMENTO*/
angular.module('budgetApp').controller('OrcamentoController', function ($scope, $http, OrcamentoServices) {

    $scope.AuthToken = function () {

        var uriBaseAuth = 'http://localhost:63867';
        var userName = 'teste@teste.com';
        var password = '123456';
        var clientId = 'client';
        var secret = "secret";

        var data = "grant_type=password&username=" + userName + "&password=" + password + "&client_id=" + clientId + "&client_secret=" + secret + "&crossDomain=true";

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            },
            async: false
        }

        if (localStorage.getItem("oAuthToken") == null) {

            $http.post(uriBaseAuth + '/token', data, config)
                .success(function (data) {
                    localStorage.setItem("oAuthToken", data.access_token);
                    localStorage.setItem("oAuthRefreshToken", data.refresh_token);
                })
                .error(function (data, status, header, config) {
                    var erro = data + ' - ' + status + ' - ' + header + ' - ' + config;
                    alert('Erro no Serviço de Token ' + erro);
                });

            //alert('novo ' + localStorage.getItem("oAuth"));
        }
    };

    $scope.LoadDataOrcamento = function () {
        //Grid Orçamento
        OrcamentoServices.get('/orcamento').success(function (data, status, headers, config) {
            $scope.orcamentos = data;
        });
    };

    $scope.LoadDataIni = function () {
        //DropDown Tipo Pagamento
        OrcamentoServices.get('/orcamento/UI/TipoPagamento')
            .success(function (data, status, headers, config) {
                $scope.tiposPagamento = data;
            })
            
        //DropDown Tipo Pessoa
        OrcamentoServices.get('/orcamento/UI/TipoPessoa')
            .success(function (data, status, headers, config) {
                $scope.tiposPessoa = data;
            })

        //DropDown Tipo Orçamento
        OrcamentoServices.get('/orcamento/UI/TipoOrcamento')
            .success(function (data, status, headers, config) {
                $scope.tiposOrcamento = data;
            })
    };

    /*************************************************************/

    $scope.IncluirOrcamento = function (orcamento) {

        if ($('#dvIncluir').is(':visible')) {

            OrcamentoServices.post('/orcamento', orcamento)
                .success(function (data, status, headers, config) {
                    $scope.LoadDataOrcamento();
                })

            $("#dvIncluir").hide(500, function () {
                $("#iconSave").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign");
            });
            //não pode ser dentro da função hide acima, não me pergunte porque
            $scope.formOrcamentoVisible = false;
        }
        else {

            $("#dvIncluir").show(500, function () {
                $("#iconSave").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk");
            });
            //não pode ser dentro da função show acima, não me pergunte porque
            $scope.formOrcamentoVisible = true;
        }
    }

    $scope.SalvarEdicaoOrcamento = function () {

        var orcamento = {
            ID: $scope.OrcamentoIdEdit,
            Descricao: $("#inputDescricao").val(),
            TipoPessoa: $("#dropTipoPessoa").val(),
            TipoPagamento: $("#dropTipoPagamento").val(),
            TipoOrcamento: $("#dropTipoOrcamento").val(),
            Fixa: $("#inputFixa:checked").length,
            TaxaPorcentagem: $("#inputTaxaPorcentagem").val()
        };

        //console.log(JSON.stringify(orcamento));

        OrcamentoServices.put('/orcamento', orcamento)
            .success(function (data, status, headers, config) {
                $scope.LoadDataOrcamento();
            })

        $("#dvIncluir").hide(500, function () {
            $("#btnSave").show(50);
            $("#btnEdit").hide(50);
            $("#iconEdit").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign")
        });
    }

    $scope.EditarOrcamento = function (orcamentoID) {

        $scope.OrcamentoIdEdit = orcamentoID;

        OrcamentoServices.get('/orcamento/' + orcamentoID)
            .success(function (data, status, headers, config) {

                //A nomenclatura Orcamento não pode ser refletida devido a algum conflito de nome
                //$scope.Orcamento = data;

                $("#inputDescricao").val(data.Descricao);
                $("#dropTipoPessoa").val(data.TipoPessoa);
                $("#dropTipoPagamento").val(data.TipoPagamento);
                $("#dropTipoOrcamento").val(data.TipoOrcamento);

                $("#inputFixa").prop('checked', data.Fixa);
                $("#inputTaxaPorcentagem").val(data.TaxaPorcentagem);

            })
            
        $("#dvIncluir").show(500, function () {
            $("#btnSave").hide(50);
            $("#btnEdit").show(50);
            $("#iconEdit").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk")
        });

    }

    $scope.ExcluirOrcamento = function (orcamentoID) {

        OrcamentoServices.delete('/orcamento/' + orcamentoID)
            .success(function (data, status, headers, config) {
                $scope.LoadDataOrcamento();
            })
    }

    /*************************************************************/

    $scope.AuthToken();
    $scope.LoadDataOrcamento();
    $scope.LoadDataIni();


/*VALOR*/

    $scope.LoadDataValor = function (orcamentoId) {

        $scope.orcamentoId = orcamentoId;

        //Grid Valor
        OrcamentoServices.get('/itemvalor/orcamento/' + orcamentoId)
            .success(function (data, status, headers, config) {
                $scope.valores = data;
            })
    };

    $scope.OpenModalValor = function (orcamentoId) {
        $('#modalValor').modal('toggle');
        $scope.LoadDataValor(orcamentoId);
    };

    $scope.ValidaFormValor = function () {
        if ($('#dvIncluirValor').is(':visible')) {
            return $scope.formValor.$invalid
        }
        return false;
    }

    /*************************************************************/

    $scope.SalvarEdicaoValor = function () {

        var valor = {
            ID: $scope.ValorIdEdit,
            Vencimento: $("#inputVencimentoValor").val()
        };

        OrcamentoServices.put('/itemvalor', valor)
            .success(function (data, status, headers, config) {
                $scope.LoadDataValor($scope.orcamentoId);
            })
            
        $("#dvIncluirValor").hide(500, function () {
            $("#btnSaveValor").show(50);
            $("#btnEditValor").hide(50);
            $("#iconEditValor").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign")
        });
    }

    $scope.EditarValor = function (valorID) {

        $scope.ValorIdEdit = valorID;

        OrcamentoServices.get('/itemvalor/valor/' + valorID)
            .success(function (data, status, headers, config) {
                $("#inputVencimentoValor").val(data.Vencimento);
            })
            
        $("#dvIncluirValor").show(500, function () {
            $("#btnSaveValor").hide(50);
            $("#btnEditValor").show(50);
            $("#iconEditValor").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk")
        });

    }

    $scope.IncluirValor = function (orcamentoId, valor) {

        if ($('#dvIncluirValor').is(':visible')) {

            var orcamento = {
                ID: orcamentoId
            };

            var valor = {
                Orcamento: orcamento,
                Vencimento: $("#inputVencimentoValor").val()
            };

            OrcamentoServices.post('/itemvalor', valor)
                .success(function (data, status, headers, config) {
                    $scope.LoadDataValor(orcamentoId);
                })
                
            $("#dvIncluirValor").hide(500, function () {
                $("#iconSaveValor").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign")
            });
            //não pode ser dentro da função hide acima, não me pergunte porque
            $scope.formValorVisible = false;
        }
        else {

            $("#dvIncluirValor").show(500, function () {
                $("#iconSaveValor").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk")
            });
            //não pode ser dentro da função show acima, não me pergunte porque
            $scope.formValorVisible = true;
        }
    }

    $scope.ExcluirValor = function (valorID) {

        OrcamentoServices.delete('/itemvalor/' + valorID)
            .success(function (data, status, headers, config) {
                $scope.LoadDataValor($scope.orcamentoId);
            })
    }


/*SUB-VALOR*/

    $scope.LoadDataSubValor = function (valorId) {

        $scope.valorId = valorId;

        OrcamentoServices.get('/itemsubvalor/valor/' + valorId)
            .success(function (data, status, headers, config) {
                $scope.subValores = data;
        })
        
    };

    $scope.OpenModalSubValor = function (valorId) {
        $('#modalSubValor').modal('toggle');
        $scope.LoadDataSubValor(valorId);
    };

    $scope.ValidaFormSubValor = function () {
        if ($('#dvIncluirSubValor').is(':visible')) {
            return $scope.formSubValor.$invalid
        }
        return false;
    }

    /*************************************************************/

    $scope.SalvarEdicaoSubValor = function () {

        var subValor = {
            ID: $scope.SubValorIdEdit,
            Valor: $("#inputSubValor").val()
        };

        OrcamentoServices.put('/itemsubvalor', subValor)
            .success(function (data, status, headers, config) {
                $scope.LoadDataSubValor($scope.valorId);
            })
            
        $("#dvIncluirSubValor").hide(500, function () {
            $("#btnSaveSubValor").show(50);
            $("#btnEditSubValor").hide(50);
            $("#iconEditSubValor").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign")
        });
    }

    $scope.EditarSubValor = function (subvalorID) {

        $scope.SubValorIdEdit = subvalorID;

        OrcamentoServices.get('/itemsubvalor/subvalor/' + subvalorID)
            .success(function (data, status, headers, config) {
                $("#inputSubValor").val(data.Valor);
            })
            
        $("#dvIncluirSubValor").show(500, function () {
            $("#btnSaveSubValor").hide(50);
            $("#btnEditSubValor").show(50);
            $("#iconEditSubValor").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk")
        });

    }

    $scope.IncluirSubValor = function (valorId) {

        if ($('#dvIncluirSubValor').is(':visible')) {

            var itemValor = {
                ID: valorId
            };

            var itemSubValor = {
                ItemValor: itemValor,
                Valor: $("#inputSubValor").val()
            };

            OrcamentoServices.post('/itemsubvalor', itemSubValor)
                .success(function (data, status, headers, config) {
                    $scope.LoadDataSubValor(valorId);
                })
                
            $("#dvIncluirSubValor").hide(500, function () {
                $("#iconSaveSubValor").removeClass("glyphicon-floppy-disk").addClass("glyphicon-plus-sign")
            });
            //não pode ser dentro da função hide acima, não me pergunte porque
            $scope.formSubValorVisible = false;
        }
        else {

            $("#dvIncluirSubValor").show(500, function () {
                $("#iconSaveSubValor").removeClass("glyphicon-plus-sign").addClass("glyphicon-floppy-disk")
            });
            //não pode ser dentro da função show acima, não me pergunte porque
            $scope.formSubValorVisible = true;
        }
    }

    $scope.ExcluirSubValor = function (subvalorID) {

        OrcamentoServices.delete('/itemsubvalor/' + subvalorID)
            .success(function (data, status, headers, config) {
                $scope.LoadDataSubValor($scope.valorId);
            })
    }

});