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
            'user': {
                edit: this.Edit
            },
            'user button[action=insert]': {
                click: this.Insert
            },
            'user button[action=delete]': {
                click: this.Delete
            },
            'user button[action=sync]': {
                click: this.Sync
            },
            'edituser button[action=aceptar]': {
                click: this.guardar
            },
            'edituser button[action=limpiar]': {
                click: this.limpiar
            }
        });
    },

    Edit: function (editor, e) {
        e.record.store.sync({
            success: function (bacth) {
                e.record.store.load();
            },
            failure: function (batch) {
                Ext.Msg.alert('Informacion', this.reader.rawData.msgs);
                e.record.store.load();
            }
        });
    },

    showEdit: function (el) {
        Ext.widget("edituser", {grid:el.up("grid")}).show();
    },

    Insert: function (el) {
        el.up('grid').store.insert(el.up('grid').store.count(),{
            Id: 0,
            Name: '',
            Email: '',
            Password: ''
        });
    },

    Sync: function (el) {
        el.up('grid').store.sync({
            success: function (bacth) {
                el.up('grid').store.load();
            },
            failure: function (batch) {
                Ext.Msg.alert('Informacion', this.reader.rawData.msgs);
                el.up('grid').store.load();
            }
        });
    },

    Delete: function (el) {
        var selection = el.up('grid').getSelectionModel().getSelection()[0];
        if (selection) {
            el.up('grid').store.remove(selection);
            el.up('grid').store.sync({
                success: function (bacth) {
                    el.up('grid').store.load();
                },
                failure: function (batch) {
                    Ext.Msg.alert('Informacion', this.reader.rawData.msg);
                    el.up('grid').store.load();
                }
            });
        }
    },

    guardar: function (el) {
        var form = el.up('form').getForm();
        if (form.isValid()) {
            form.submit({
                success: function (form, action) {
                    var msg = "";
                    if (action.result.errors) {
                        for (var i = 0; i < action.result.errors.length; i++) {
                            msg += "- " + action.result.errors[i] + "<br>";
                        }
                    }
                    Ext.Msg.alert('Informacion', (msg==""?action.result.msg:msg));
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

