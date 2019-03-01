export const navItems = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Student',
    url: '/student',
    icon: 'icon-graduation',
    children: [
      {
        name: 'Student List',
        url: '/student/list',
        icon: 'icon-list'
      }
    ]
  },
];
