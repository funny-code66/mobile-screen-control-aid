<?php

defined('BASEPATH') or exit('No direct script access allowed');

$route['default_controller'] = 'welcome';
$route['404_override'] = '';
$route['translate_uri_dashes'] = FALSE;

//// BEGIN ADMIN ROUTE /////
$route['admin'] = 'admin/dashboard';
$route['admin/terms'] = 'admin/dashboard/terms';

$route['admin/gigs/(:any)'] = 'admin/gigs/index/$1';
$route['admin/gig_activate'] = 'admin/gigs/gig_activate';
$route['admin/admin_delete_gigs'] = 'admin/gigs/admin_delete_gigs';

$route['admin/projects/(:any)'] = 'admin/projects/index/$1';
$route['admin/admin_delete_projects'] = 'admin/projects/admin_delete_projects';

$route['language/pages'] = 'admin/language/pages';
$route['language/pages/(:any)'] = 'admin/language/language';
$route['language_list'] = 'admin/language/language_list';
$route['language_web_list'] = 'admin/language/language_web_list';
$route['language/add-keyword/(:any)'] = 'admin/language/add_keyword';
$route['language/add-page'] = 'admin/language/add_page';
$route['language/keywords'] = 'admin/language/keywords';
$route['language/add-web-keyword'] = 'admin/language/add_web_keyword';

$route['admin/membership'] = 'admin/membership/index';
$route['admin/membership/create'] = 'admin/membership/create_membership';
$route['admin/membership/edit/(:any)'] = 'admin/membership/edit_membership/$1';
$route['admin/membership_detail'] = 'admin/membership/membership_detail';
$route['admin/membership_detail/c