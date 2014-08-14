Ext.define('MyApp.view.EditUserView', {
    extend: 'Ext.window.Window',
    alias:'widget.edituser',
    title: 'Edit',
    height: 200,
    width: 305,
    grid:{},
    modal:true,
    layout: 'border',
    items: [
        {
            xtype: 'form',
            url: '/User/Guardar',
            region: 'center',
            bodyPadding:5,
            items: [
                {
                    xtype:'textfield',
                    fieldLabel: 'ID',
                    name: 'id',
                    allowBlank: false,
                    value: '0',
                    readOnly: true
                }, {
                    xtype: 'textfield',
                    fieldLabel: 'Name',
                    name: 'name',
                    allowBlank: false
                }, {
                    xtype: 'textfield',
                    fieldLabel: 'Email',
                    name: 'email',
                    vtype: 'email'
                }, {
                    xtype: 'textfield',
                    fieldLabel: 'Password',
                    name: 'password',
                }
            ],
            buttons: [{
                text: 'Limpiar',
                action:'limpiar'
            }, {
                text: 'Aceptar',
                formBind: true,
                disabled: true,
                action:'aceptar'
            }]
        }
    ]
});