Ext.define('MyApp.view.UserView', {
    extend: 'Ext.grid.Panel',
    title: 'Users',
    alias: 'widget.user',
    store: 'UserStore',
    flex: 1,
    layout:{
        type:'fit'
    },
    renderTo: 'panelExtjs',
    columns: [
        { text: 'ID', dataIndex: 'Id' },
        {
            text: 'Name',
            dataIndex: 'Name',
            editor: {
                xtype: 'textfield',
                allowBlank: false
            }
        },
        {
            text: 'Email',
            dataIndex: 'Email',
            flex: 1,
            editor: {
                xtype: 'textfield',
                allowBlank: false
            }
        },
        {
            text: 'Password',
            dataIndex: 'Password',
            flex: 1,
            editor: {
                xtype: 'textfield',
                allowBlank: false
            }
        }
    ],
    dockedItems: [{
        xtype: 'toolbar',
        dock: 'top',
        items: [{
            text: 'New (form)',
            hidden:true,
            action: 'new'
        },
        {
            text: 'New',
            action: 'insert'
        },
        {
            text: 'Delete',
            action: 'delete'
        },
        {
            text: 'Save',
            hidden:true,
            action: 'sync'
        }]
    }],
    plugins: {
        ptype: 'cellediting',
        clicksToEdit: 1
    }
    
});