Ext.define('MyApp.controller.UserController', {
    extend: 'Ext.app.Controller',
    views: [
        'UserView',
        'EditUserView'
    ],
    stores:[
        'UserStore'
    ],
    init: function () {
        Ext.widget("user").show();
        this.control({
            'user button[action=new]': {
                click: this.showEdit
            },
            'edituser button[action=aceptar]': {
                click: this.guardar
            },
            'edituser button[action=limpiar]': {
                click: this.limpiar
            }
        });
    },

    showEdit: function (el) {
        Ext.widget("edituser", {grid:el.up("grid")}).show();
    },

    guardar: function (el) {
        var form = el.up('form').getForm();
        if (form.isValid()) {
            form.submit({
                success: function (form, action) {
                    
                    Ext.Msg.alert('Success', action.result.msg);
                    if (action.result.success) {
                        el.up('window').grid.store.load();
                        el.up('window').close();
                    }
                },
                failure: function (form, action) {
                    Ext.Msg.alert('Failed', action.result.msg);
                }
            });
        }
    },

    limpiar: function (el) {
        el.up('form').getForm().reset();
    }
});

