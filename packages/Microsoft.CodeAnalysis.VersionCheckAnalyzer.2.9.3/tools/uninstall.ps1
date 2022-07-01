= 'user/gigs/load_more_feedbacks';
$route['load_more_userfeedbacks'] = 'user/gigs/load_more_userfeedbacks';
$route['devicedetails'] = 'user/gigs/devicedetails';


//Projects
$route['add-project'] = 'user/projects/add_project';
$route['edit-project/(:any)'] = 'user/projects/edit_project/$1';
$route['edit-project/(:any)/(:any)'] = 'user/projects/edit_project/$1/$2';
$route['save-project'] = 'user/projects/save_project';
$route['my-project'] = 'user/projects/my_project';
$route['buy-project'] = 'user/projects/buy_project';
$route['buy-project/(:any)'] = 'user/projects/buy_project/index/$1';
$route['project-preview'] = 'user/projects/project_preview';
$route['project-preview/(:any)'] = 'user/projects/project_preview/$1';
$route['project-preview/(:any)/(:any)'] = 'user/projects/project_preview/$1/$2';
$route['project-proposals/view/(:any)'] = 'user/projects/project_proposals/$1';
$route['project-proposals/award'] = 'user/projects/proposal_award';
$route['project-proposals/accept'] = 'user/projects/proposal_accept';
$route['project-proposals/create_milestone'] = 'user/projects/proposal_create_milestone';
$route['project-proposals/request_milestone'] = 'user/projects/proposal_request_milestone';
$route['project-proposals/release'] = 'user/projects/proposal_release';
$route['project-proposals/cancel'] = 'user/projects/proposal_cancel';

//Team Management
$route['team_management'] = 'user/team_management';
$route['team_management/invite/(:any)'] = 'user/team_management/invite_developer/$1';
$route['team_management/exit/(:any)'] = 'user/team_manageme